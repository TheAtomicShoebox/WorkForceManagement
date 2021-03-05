# WorkForceManagement  
---  
An ASP.NET Web API intended to allow you to manage employees amongst multiple locations, tracking and modifying information about their role, their pay rate, their employment status, and of course, their name.  

---
## Employee

int EmployeeId [PK] | string FirstName | string LastName | int RoleId [FK] | int StoreLocationId [FK] | bool IsActive | double PayRate |
--- | --- | --- | --- | --- | --- | --- |
0001 | Harald | Godwinson | 0001 | 0001 | false | 25.00


StoreLocation Location (nav Property) | EmployeeRole Role (nav Property)
--- | --- |
Location with id 0001 | Role with id 0001

`EmployeeId` is the Primary Key, and as such is not specified during `Employee` creation.
The employee’s name is made up of `FirstName` and `LastName`, where both are strings. It also exposes a non-data, readonly property `FullName`, which constructs their full name from the constituent parts and adds a space. So “John” “DiMaggio” becomes
“John DiMaggio”.
The `RoleId` and `StoreLocationId` are associated with their Navigation Properties, held only as reference to the other tables in the database.
`Employee` has a many-to-one relationship with both `EmployeeRole` and `StoreLocation`

### Employee Endpoints
---
**GET All**
**GET** `http://website.com/api/Employee/`
This returns the list of all Employees

**GET By Id**
**GET** `http://website.com/api/Employee/{id}/`
This returns the one employee whose `EmployeeId` matches `id`

**Create New Employee**
**POST** `http://website.com/api/Employee/`
This allows the creation of a new Employee. The fields allowed are:
`FirstName`, `LastName`, `RoleId`, `StoreLocationId`, `PayRate`, `IsActive`
Of those, the name properties, `RoleId`, and `StoreLocationId` are required.

**Change Employee Status**
**PUT** `http://website.com/api/Employee/ChangeEmployeeStatus/{id}`
This allows for swapping the status of an employee (`IsActive`) to and from `true`.
This only inverts the status, so use in conjunction with the GET by id method is important.

**Update Employee**
**PUT** `http://website.com/api/Employee`
This allows for updating the several properties of an Employee. This is done by passing a model into the body of the request. Any combination of `EmployeeId`, `FirstName`, `LastName`, `RoleId`, `RoleName`, `StoreLocationId`, `StoreName`, and `PayRate` can be changed.

## StoreLocation

int StoreNumber [PK] | string StoreName | string StreetAddress | ICollection<Employee> Employees |
--- | --- | --- | --- |
0001 | JD Greenwood | 1234 Main Street | List of Employees associated with StoreNumber 0001
  
`StoreNumber` is the Primary Key, and as such is not specified during `Store` creation.
Navigation property `Employees` is defined on the StoreLocation entity type and navigates a one-to-many association between one store to many employees. 

### StoreLocation Endpoints
---
**GET All**
**GET** `http//website.com/api/Store/`
Returns to user the list of all Stores

**GET By Number**
**GET** `http://website.com/api/Store/{number}/`
Returns to user one store where `StoreNumber` matches `number`

**Create New Store**
**POST** `http://website.com/api/Store/`
Allows the user to create a new Store by passing the Storecreate model into the body of the request. The fields allowed are:`StoreName`, `StreetAddress`, where `StoreID` is automatically created upon creation. The properties, `StoreName`, and `StreetAddress` are required.

**Update Store**
PUT `http://website.com/api/Store/`
Allows the user to update properties of a Store. This is done by passing the StoreEdit model into the body of the request. Any combination of `StoreID`, `StoreName`, `StreetAddress`, can be changed.

**Delete Store**
PUT `http://website.com/api/Store/{storeNumber}/`
Allows the user to delete a store where `StoreNumber` matches `storeNumber`

