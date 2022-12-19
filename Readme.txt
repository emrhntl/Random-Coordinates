Author : Emirhan ETLİ Date created: 19/12/2022 This script generates the desired number of random coordinates from within the rectangular area created by the determined
4 coordinates. When the largest and smallest meridian values and the largest and smallest parallel values of the region where random coordinate values will be generated 
are entered, the smallest parallelogram surrounding the relevant area is found. For example, when finding the largest and smallest coordinate values for a region in the 
northern and eastern hemispheres: the parallel of the southernmost point of the area is the smallest parallel, the parallel of the northernmost point is the largest 
parallel, the meridian of the westernmost point is the smallest meridian, and the meridian of the easternmost point is the smallest meridian. Naturally, some selected 
points will be inside the created peripheral parallelogram, but outside the desired area (which is most likely an irregularly shaped area). In this case, re-running the 
script and generating new coordinates was considered as a solution. In order for all generated random coordinates to be in the desired area, a script that requires 
entering much more coordinates or spacial data and image processing will be required. In this respect, the script given here offers a relatively simple solution, even if 
it is incomplete
The path of the program's execute file is "Random Coordinates\Random Coordinates\bin\Debug\net5.0-windows\Random Coordinates.exe".
You must have .net5 on your computer to run the program. If it is not installed, when you click on the execute file, the system will usually notify you that you need to download it and ask if you want it to be downloaded. If you approve, the .net5 download will take place automatically if you are connected to the internet and you will be able to run the application without any problems.
