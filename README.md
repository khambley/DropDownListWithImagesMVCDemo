# DropDownList With Images ASP.NET MVC4+ Demo
This is an updated version of Jeff Johnson's Adding Images to Select Lists in MVC3 except I'm using Jquery UI SelectMenu widget. 
The msdropdown plugin he used was abandoned 5 years ago and doesn't work anymore with .NET.

Here is Jeff's old code from 2012 [jeffjohnson9046/MVC3-ImagesInSelectLists](https://github.com/jeffjohnson9046/MVC3-ImagesInSelectLists/blob/master/MVC3.ImagesInDropdownLists/Views/Contestant/Create.cshtml)

Here is Jeff's blog explaining his implementation. [ADDING IMAGES TO SELECT LISTS IN MVC3](http://fairwaytech.com/2012/08/adding-images-select-lists-mvc3/)

### I changed a few things in his ImageSelectExtensions.cs file:
* Instead of adding the ImagePath to the title attribute in the ```<option>``` tags for the SelectListItem, I needed to add the "data-class" and "data-style" attributes to the ```<option>``` tags for the jQuery UI plugin. This is done in the ListItemToOption method on line 159...
```
if (!string.IsNullOrEmpty(imagePath))
    {
        builder.Attributes["data-class"] = "ddlImage";
        builder.Attributes["data-style"] = "background-image: url('" + BuildFullImagePath(imagePath, 
        item.ImageFileName) + "');";
    }
```
* I added the text "--Select an option--" at the top of the DropDownList as generic text with an empty Value and Selected = false.
```
// The display text on the first line in the dropdown KLH 11-25-18
            listItemBuilder.AppendLine(ListItemToOption(new ImageSelectListItem() { 
            Text = "--Select an option--", Value = String.Empty, Selected = false }));
```
### Changes to the View (Create.cshtml)
* I added the class "ddlImage" to my CSS so I can custom style the dropdown image and position it properly.
```
/* select with CSS custom images */
    option.ddlImage {
        background-repeat: no-repeat !important;
        padding-left: 20px;
    }

    .ddlImage .ui-icon {
        background-position: left top;
    }
```
* Then, I add the script at the top of the View (Create.cshtml) to implement the 
jQuery UI plugin and initialize the widget.
```
<script>
    $(function () {
        $.widget("custom.iconselectmenu", $.ui.selectmenu, {
            _renderItem: function (ul, item) {
                var li = $("<li>"),
                    wrapper = $("<div>", { text: item.label });

                if (item.disabled) {
                    li.addClass("ui-state-disabled");
                }

                $("<span>", {
                    style: item.element.attr("data-style"),
                    "class": "ui-icon " + item.element.attr("data-class")
                })
                    .appendTo(wrapper);

                return li.append(wrapper).appendTo(ul);
            }
        });

        $("#selectCountry")
            .iconselectmenu()
            .iconselectmenu("menuWidget")
            .addClass("ui-menu-icons ddlImage");
    });
</script>
```
### In the Controller (HomeController):
* I did things a little differently with data persistence. Instead of using a mock repository, I used Code First Migrations to create a local database. I created a connection String and added it to my Web.config. If you are using this project and using the Entity Framework, be sure to change your connection String to whatever data connection you are using.
```
 <connectionStrings>
    <add name="DropDownListDbConnection" connectionString="Data Source=katherine-alien\sqlexpress;Initial
    Catalog=DropDownListDemoDb;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
```
* The Create action method is the same as Jeff's. I'm just returning a ViewModel to the Create view.
* The HttpPost Create action method is very different from Jeff's because I'm using the Entity Framework. This saves the POST data to my local db.
```
[HttpPost]
public ActionResult Create([Bind(Include = "ContestantId,FirstName,LastName,Age,CountryId")] 
Contestant contestant)
{
    if (ModelState.IsValid)
    {
        _db.Contestants.Add(contestant);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(contestant);
}
 ```
 ### Jquery UI Plugin:
* Be sure to install the latest version of jQuery-ui.js and css as well as jQuery. I had to include the jQuery library at the top of my View in order for it to work but I'm sure you could use a document.ready function instead and it would work without it.
* For JQuery UI documentation, examples, and the source code, view the official page [here](https://jqueryui.com/selectmenu/#custom_render)

### Here is a screenshot of my implementation:
I'm working on a live demo but I have to set up my web server again, so here is a screenshot for now.

![DropDownList Image Screenshot](/images/screenshot1.png)

### A few tips:
* Be sure to add the two classes, **ImageSelectExtensions.cs** and **ImageSelectListItem.cs** to your project. 
* I used AutoMapper like Jeff did, but updated it so it works with version 6.2. They changed the API so I had to change the calls to CreateMap and Mapper, see Global.asax.cs. 

I think the ImageSelectListItem with the IEnumerable implemenation is a little clunky especially with having the separate classes, ImageSelectListItem and Country. Why can't the ImageSelectListItem property just be included in the Country model? Maybe so it is reusable? 

I think there is an easier way, I'd like to refactor the code so I can just use a list with the DropDownList HTML helper instead of an IEnumerable. And I don't see why you can't just add the List to a ViewModel and retrieve it as a list from the database. 

Anyway, hope this helps and let me know any suggestions you might have! Thanks! 

Katherine
Twitter - @superdesigngirl
Facebook - /khambley
Email - superdesigngirl@mac.com

         

