**Author**: Emirhan ETLİ
**Date created**: 19/12/2022

The path of the program's executable file is `"Random Coordinates\Random Coordinates\bin\Debug\net5.0-windows\Random Coordinates.exe"`.

To run the program, you must have .NET 5 installed on your computer. If it is not installed, when you click on the executable file, the system will typically notify you that you need to download it and ask if you want to proceed with the download. If you approve, the .NET 5 download will take place automatically if you are connected to the internet. Once installed, you will be able to run the application without any issues.

This script generates a specified number of random coordinates within a rectangular area defined by four determined coordinates. By inputting the minimum and maximum meridian values and the minimum and maximum parallel values of the region, the script finds the smallest parallelogram that encloses the relevant area. For example, when determining the coordinate values for a region in the northern and eastern hemispheres, the parallel of the southernmost point represents the minimum parallel, the parallel of the northernmost point represents the maximum parallel, the meridian of the westernmost point represents the minimum meridian, and the meridian of the easternmost point represents the maximum meridian.

Naturally, some selected points may fall within the created peripheral parallelogram but outside the desired area, which is typically an irregularly shaped area. In such cases, the script suggests re-running it to generate new coordinates as a solution. For all generated random coordinates to fall within the desired area, a more complex script would be required, involving the input of additional coordinates or spatial data and utilizing image processing techniques. Nevertheless, the provided script offers a relatively simple solution, albeit incomplete, in this regard.
