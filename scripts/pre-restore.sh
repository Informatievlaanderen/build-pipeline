#!/bin/bash

if [ -z "$1" ]; then
  echo "Error: Version is not provided."
  echo "Usage: $0 <version>"
  exit 1
fi

PACKAGE_NAME="Be.Vlaanderen.Basisregisters.Build.Pipeline"
PACKAGE_VERSION="$1"
NUGET_SOURCE="https://www.nuget.org/api/v2/package"
OUTPUT_DIR="./packages"
TEMP_DIR="./temp-nuget"

# download
echo "Downloading $PACKAGE_NAME version $PACKAGE_VERSION..."
PACKAGE_URL="$NUGET_SOURCE/$PACKAGE_NAME/$PACKAGE_VERSION"
mkdir -p "$TEMP_DIR"
curl -L "$PACKAGE_URL" --output "$TEMP_DIR/$PACKAGE_NAME.$PACKAGE_VERSION.nupkg"

# extract
echo "Extracting .props file..."
rm -rf "$OUTPUT_DIR/$PACKAGE_NAME"
mkdir -p "$OUTPUT_DIR/$PACKAGE_NAME"
unzip -j "$TEMP_DIR/$PACKAGE_NAME.$PACKAGE_VERSION.nupkg" -d "$OUTPUT_DIR/$PACKAGE_NAME/Content"

# cleanup
echo "Cleaning up..."
rm -rf "$TEMP_DIR"

echo "Done! Props file is located in $OUTPUT_DIR."