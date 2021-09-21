Swagger Petstore 

The project is done using .Net and C#

The project uses the sample API https://petstore.swagger.io/v2/pet/findByStatus?status=available to get a list of available pets from the Pet Store.

The project is created as a console application.

There are virtual models to get data in the required form in PetStoreModel.cs file.

The logic and functions are written in Program.cs file.

The json output from the API is deserialized to load into memory using jsonConvert and then the list is filtered if there exists the Category.

availablepets function returns the list of all the available pets who has a category.

distinctCatagory function return the list of distict catagories with their corresponding list<string> pet names.

sortedData function sorts the categories and get the pet names in reverse order.

printTheOutput function prints the list of available pets under the category in sorted order with the pet names in reverse order, the list is printed using unicode encoding to print unicode characters from the API.

unitTest function asks the user to enter any category name from the above displayed output (entered category is case sensitive), the output gives all the 
avaliable pets for that category, which should be same as the above list output in the console, if it is same then the test is successfull.
