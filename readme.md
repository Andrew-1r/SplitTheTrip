# New project

Playing around with ASP.NET Core MVC to make a webapp for tracking expenses in groups.

# Minimum viable product

users create an account with an email and username and sign in to the webapp.

a user can make a new group and add any number of other group members. a group id and pin will be created, anyone with this id can add expenses to the group

a group can be made the "default" and be the first thing that appears when a user opens the webapp.

inside of a group, the group members name and credits / debits will be displayed. there will also be a button to settle and a button to review previous expenses.

inside of a group, a persons name can be selected and the add expense screen will come up.

In the expense screen, a user inputs a name for the expense and the total amount thats paid, and how it was split amongst the group members.

this can be an equal split, a specific dollar value split, or a specific % amount for each group user.

any amount that isnt caught in custom splits will be equally split amongst the group.

# db modelling

```c
Table user {
    id int [pk]
    username varchar
    email varchar
    password_hash varchar // look up ASP.NET Identity for storage
}

Table group {
    id int [pk]
    pin_hash varchar // hashed
    owner_id int [ref: > user.id] // represents group owner
    name varchar // anyone with group id can add transactions, only owner can remove transactions, edit names, and add/remove group members
}

Table group_member {
    id int [pk]
    group_id int [ref: > group.id]
    is_owner boolean
    name varchar
}
Table total_expense {
    id int [pk]
    group_id int [ref: > group.id]
    payer_id int [ref: > group_member.id]
    name varchar
    total_amount decimal
    created_at datetime
    is_deleted bool
}
Table individual_expense {
  id int [pk]
  total_expense_id int [ref: > total_expense.id]
  member_id int [ref: > group_member.id] // who owes or is owed
  payer_id int [ref: > group_member.id]  // who paid
  amount decimal(10,2) // final calculated amount, can be negative or positive
  split_type varchar // 'percent' or 'flat'
  split_value decimal(10,2) // original percentage or flat value
}
```
