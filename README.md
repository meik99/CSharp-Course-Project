# Itemized Bill

This project implements a tool, with which an itemized bill can be calculated.
It consists of the following features.

## Add

By clicking on the "Add" Button, an item can be added to the list of items.
The form that opens after clicking the button takes a name for the item and a price.
Clicking on "Confirm" adds the item to the underlying in-memory database and returns
to the list view. Clicking on "Cancel" cancels the process and returns to the list view without adding an item.

## Delete

After one or more items have been selected in the list view, the "Delete" button enables 
itself.
Clicking on it spawns a confirmation dialog. A positive response to this dialog, results in 
deletion of the selected items from the database. A negative response cancels the process and
no items will be deleted.

## Modify

If one and only one item is selected in the list view, the "Modify" button enables itself.
Clicking on it spawns a dialog, in which name and amount can be edited. By confirming
this dialog, the modified values will be saved in the database, while canceling the process
will have no effect. Both actions return the user to the list view.

## List

In the main window, a list of all added items can be seen.
Multiple items are selectable. 

## Sum

In the upper right corner of the main window, a label is displayed. It contains the word
"Sum: " along with the sum of all prices of the added items. 
It dynamically changes, if items are added, modified or deleted.

# Unit Tests

This project contains unit tests for most non UI-related functionalities.
These include database modification through repositories, as well as 
interaction via facades.