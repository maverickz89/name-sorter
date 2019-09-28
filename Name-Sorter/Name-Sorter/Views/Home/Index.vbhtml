@Code
    ViewData("Title") = "Home Page"
End Code

<h2>@ViewData("Message")</h2>
Place your name-to-be-sorted to folder App_Data as "unsorted-names-list.txt"
<h3>Sorted Name:</h3>
@For Each peopleName In ViewData("sortedName")
    @peopleName.getName()@<br />
Next