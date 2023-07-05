# Parser Tools

This is a project that contain tools for parsing data files into objects.

## Annotations

There are different kind of annotations that can be used on classes in this project.<br/>

### UnwantedCharsAttribute

This attribute can only be applied on a class.<br/>
It defines a list of unwanted characters in the data
what will be converted into a class.

### DataSplitterAttribute

This is for splitting data into an array using a split character.<br/>
This attribute can only be applied on a class.<br/>
It is possible to define an array of unwanted characters, that will
be removed from data before it is returned.

### FieldIndexedAttribute

This is for using together with the DataSplitterAttribute.<br/>
The index is for setting the data index of a field in the class.<br/>
It is possible to define an array of unwanted characters, that will
be removed from data before it is returned.

### FieldFixedAttribute

This is for getting data at a specific position with a specific length.<br/>
It is possible to define an array of unwanted characters, that will
be removed from data before it is returned.

### FieldTagAttribute

This if for selecting data using a start-tag and a end-tag.<br/>
The attribute is for variables in a class.<br/>
It is possible to define an array of unwanted characters, that will
be removed from data before it is returned.
