# Expense Management system!

This project is a MVP for the challenge for the position of  **ASP.NET Software Engineering**. 
In this project, 

## About this project

- Also this project is built wilth .net core 2.2 with Ef Core code first. 
- EMS.Database consits of database project. Simply publish this to any database for up and running.
- Since this is code first, database can be updated from code as well.
- EMS.Website is webapplication to be published and deployed.

## Employee

- Employee is required to fill the receipt form with uploading receipt. 
- In Index page, Employee will see all of his/her uploaded receipt info. 
- Which he/she will be able to create new, edit, delete or just peek reciept image.
- On Create page, apart from filling up travel detail and uploading photo of receipt, employee will also be able to add expenses by clicking button **Add Expense**. 
```
Remaining Task: If there is any extra detail in case of miscelleneous, then the new form should open for uploading them as well. Since the field were unclear, its been left till further clarification.
```

## Team Lead

- Team lead is required to approve the  receipt uploaded by employee. 
- In Index page, Team lead will see all the expense information uploaded by employee.
- If any employee fills travel expense details, its respective Team lead will receive email. 
- Also, he/she will be able to create new, edit, delete or just peek receipt image.

## Finance

- Finance will receive notification mail when any receipt will be approved by Team lead.
- Finance will also be able to see index and edit page. But he will not be able to approve or modify expenses information.

```
Report generation and export to excel feature is yet to be completed because of time constrains.
``` 

## Admin

- Admin is currently allowed to perform all the task permitted for employee as well as Team Lead.
- Admin will be responsible for managing authentication and authorization.  

## User

- All user will be able to register, change password or use forgot password for recovering old password.

```
Another remaining task that couldn't be completed because of time constraints is unit testing. 
```  
