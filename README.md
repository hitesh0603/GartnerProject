### How to use it
* go to GartnerApplication\bin\release folder and open GartnerApplication.exe
* it will ask the file name. we can give multiple files with comma separated eg. abc.json,read.yaml etc
* after reading all files content, it'll create a new json file and store all data in same format


### where to find code
* GartnerApplication
	- ReadAllSources: it'll desrialize all the type of file
	- InsertIntoFile: it'll create a new json file with output
* GartnerApplicationUnitTest
	- Added few unit test cases
	
	
### Was it your first time writing a unit test, using a particular framework, etc?
* No, I have worked on NUnit test framework

### What would you have done differently if you had had more time
* I tried to search common package to desrialize but could not find. I could have search more if time permits
* Found one package to convert in json file: GroupDocs.Conversion. But yaml file is not supported with this package.
* Definitle i could have create interface and implement with the dependecy injection. 

