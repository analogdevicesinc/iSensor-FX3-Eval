The example script connects to an FX3 board, blinks the user-addressable LED, and continuously reads the primary output registers from an ADIS1650x IMU.

This example requires PythonNet ([link](https://github.com/pythonnet/pythonnet/wiki)) to be installed. The PythonNet package can easily be installed by issuing the following command: `pip install pythonnet`

**NOTE:** This example uses hard-coded paths to locate resources based on the FX3 API repository structure. To use this example as a stand-alone application outside of this repository, the paths to the necessary .dll files (contained within the `resources` folder in the root of this repository) should be updated to reflect the new folder structure. 

