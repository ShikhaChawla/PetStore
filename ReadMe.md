# **Pet Store**

This project prints the list of available pets sorted in Categories and displayed in reverse order by pet names.

The project is done using **.Net and C#** and is created as a console application.

### Working

It uses the sample API https://petstore.swagger.io/v2/pet/findByStatus?status=available to get a list of available pets from the Pet Store.

There are virtual models to get data in the required form in PetStoreModel.cs file.

The logic and functions are written in Program.cs file.

The json output from the API is deserialized to load into memory using jsonConvert and then the list is filtered, if there exists the Category for the pet name.

availablepets function returns the list of all the available pets who has a category.

distinctCatagory function return the list of distict catagories with their corresponding list of pet names.

sortedData function sorts the categories and get the pet names in reverse order.

printTheOutput function prints the list of available pets with the category in sorted order and pet names in reverse order, the list is printed using unicode encoding to print unicode characters from the API.
  
  ![List of pets, sorted in Category, printed in reverse order by per name](https://github.com/ShikhaChawla/PetStore/blob/main/feeds/Capture.PNG )

unitTest function asks the user to enter any category name from the above displayed output (entered category is case sensitive), the test case gives all the 
avaliable pets for that category, which should be same as the above list output in the console, if it is same then the test is successfull.
  
  ![Unit Test Successful if the output of the entered category is same as in the list](https://github.com/ShikhaChawla/PetStore/blob/main/feeds/Capture1.PNG)
  

