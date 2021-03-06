# WorkForceManagement  
---  
An ASP.NET Web API intended to allow you to manage employees amongst multiple locations, tracking and modifying information about their role, their pay rate, their employment status, and of course, their name.  

## How To Use
To use WorkForceManagement, clone the repository, open it in Visual Studio, and run (IIS Express). This will pull up a web page that documents the various endpoints. Then, you can use that as a reference to base your own code off of, or you can use Swagger to create and manage your own database.
Another possibility is to clone the repository and copy the files to your own project, but this will take extra work.

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

## EmployeeRole

int RoleId [PK] | string RoleName | string RoleDescription | double BaseRate | bool IsSupervisor | ICollection<Employee> Employees |
--- | --- | --- | --- | --- | --- |
0001 | Lead Shoe Shiner | Shine all the shoes. Wrangle other shoe shiners. | 57.23 | true | List of employees associated with RoleId 0001. |


`RoleID` is the primary key and is not specified during role creation.

Navigation property `Employees` navigates a one-to-many association between one `RoleId` and many `Employees`.

### EmployeeRole Endpoints
---
**Create Role**
POST http://website.com/api/Role/
Creating an Employee Role prompts the user to input `RoleName`, `RoleDescription`, `BaseRate`, and `IsSupervisor` values. `RoleId` is the primary key and is automatically generated with each new role.

**GET All Roles**
GET http://website.com/api/Role/
Returns a list of all roles that have been created. Roles are displayed using a concise `RoleID`/`RoleName` model.

**GET Role By ID**
GET http://website.com/api/Role/{id}/
This endpoint returns a detailed model of a specific role (given the `RoleID`). `RoleId`, `RoleName`, `RoleDescription`, `BaseRate`, and `IsSupervisor` are displayed.

**Update Role**
PUT http://website.com/api/Role/{id}/
This endpoint allows the user to update a single role (given the ID). Users can update `RoleName`, `RoleDescription`, `BaseRate`, and `IsSupervisor` status.

**Delete A Role**
DELETE http://website.com/api/Role/{id}/
This endpoint prompts the user for a `RoleId` and removes the existing role from the database.

## Credits
---
HTTP Request Methods
https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods

Git Conflict Resolution
https://stackoverflow.com/questions/50012036/github-cant-rebase-my-feature-branch-this-branch-cannot-be-rebased-due-to-con

Git Octopus Merge
https://stackoverflow.com/questions/6520905/git-octopus-merge-order-of-multiple-branches
https://stackoverflow.com/questions/5292184/merging-multiple-branches-with-git

HTTP response status codes
https://developer.mozilla.org/en-US/docs/Web/HTTP/Status

EFA Zoom
https://zoom.us/my/amandaknight?pwd=V2RqVVE0WEo4azVYYks0UVVuM1YxUT09

Linq Async
https://stackoverflow.com/questions/35011656/async-await-in-linq-select

User.Identity Issue Resolution
https://stackoverflow.com/questions/33951881/user-identity-getuserid-returns-null-after-successful-login

EF Readonly
https://stackoverflow.com/questions/10385248/ignoring-a-class-property-in-entity-framework-4-1-code-first
