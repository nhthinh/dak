https://docs.google.com/spreadsheets/d/1BWskK1DAn9V2Ybx-sswITQseNVxqnwEL9MugV_5OmxM/edit#gid=0

- Layout:
1. Materpage has RenderBody() to another pages render in
2. All View started by _ViewStart.cshtml  with Layout 
	   Layout = "~/Views/Shared/_MasterPage.cshtml";
3. In Homepage, we use 2 partial view
 	- PostItem
	- ListCheckbox
4. List checkbox loads dynamically by quickerfilter.js 
	  $('#divPartialThanhPhoFilter').load('/DAK/ListCity');
	- ListCity is method in controller in DAK Controller that is
	  return PartialView("~/Views/Modules/_ListCheckbox.cshtml", "City");