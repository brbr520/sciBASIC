#Code style guidelines for Microsoft VisualBasic
------------------------------------------------
##Common Architecture of a CLI program

There is a VisualBasic application helper module that define in the namespace:
[Microsoft.VisualBasic.App]()

    Module Program

        ''' <summary>
    	''' This is the main entry point of your VisualBasic application.
    	''' </summary>
    	''' <returns></returns>
    	Public Function Main() As Integer
        	Return GetType(CLI).RunCLI(App.CommandLine)
    	End Function
	End Module

Where, the type **CLI** is the CLI interface which it is a module that contains all of the CLI command of your application. And the extension function **RunCLI** is a CLI extension method from the VisualBasic App helper: [Microsoft.VisualBasic.App](). The property value of **App.CommandLine** is the commandline argument of current application that user used for start this application and calling for some _CLI_ command which is exposed in **CLI** module.

###How to define the CLI module?
A **Module** is a static _Class_ type in the VisualBasic, and it usually used for _the API exportation and common method definition for a set of similarity or functional correlated utility functions_.

And then so that the CLI module in the VisualBasic can be explained as: **A module for exposed the CLI interface API to your user.**

Here is a example:

	Partial Module CLI

    	<ExportAPI("/Print", Usage:="/Print /in <inDIR> [/ext <ext> /out <out.Csv>]")>
    	Public Function Print(args As CommandLine.CommandLine) As Integer
        	Dim ext As String = args.GetValue("/ext", "*.*")
        	Dim inDIR As String = args - "/in"
        	Dim out As String = args.GetValue("/out", inDIR.TrimDIR & ".contents.Csv")
        	Dim files As IEnumerable(Of String) =
            	ls - l - r - wildcards(ext) <= inDIR
        	Dim content As NamedValue(Of String)() =
            	LinqAPI.Exec(Of NamedValue(Of String)) <= From file As String
                                                      	In files
                                                      	Let name As String = file.BaseName
                                                      	Let genome As String = file.ParentDirName
                                                      	Select New NamedValue(Of String)(genome, name)
        	Return content.SaveTo(out).CLICode
    	End Function
	End Module

###How to expose the CLI interface API in your application?

A wrapper for parsing the commandline from your user is already been defined in namespace: [**Microsoft.VisualBasic.CommandLine**]()

And the **CLI** interface should define as in the format of this example:

	Imports Microsoft.VisualBasic.CommandLine
	Imports Microsoft.VisualBasic.CommandLine.Reflection

	<ExportAPI("/Print", Usage:="/Print /in <inDIR> [/ext <ext> /out <out.Csv>]")>
	Public Function CLI_API(args As CommandLine) As Integer


##List(Of T) operation in VisualBasic

	Dim source As IEnumerable(Of <Type>)
	Dim list As New List(of <Type>)(source)

For Add a new instance

	list += New <Type> With {
    	.Property1 = value1,
        .Property2 = value2
    }

For Add a sequence of new elements

	list += From x As T
    		In source
    		Where True = <test>
            Select New <Type> With {
            	.Property1 = <expression>,
                .Property2 = <expression>
            }

if want to removes a specific element in the list

	list -= x

Or batch removes elements:

	list -= From x As T
    		In source
            Where True = <test>
            Select x

Here is some example of the list **+** operator

	' This add operation makes the code more easily to read and understand:
    ' This function returns a list of RfamHit element and it also merge a
    ' list of uncertainly elements into the result list at the same time
    Public Function GetDataFrame() As RfamHit() Implements IRfamHits.GetDataFrame
        Return hits.ToList(Function(x) New RfamHit(x, Me)) + From x As Hit
                                                             In Uncertain
                                                             Select New RfamHit(x, Me)
    End Function

And using the **+** operator for add a new object into the list, this syntax can makes the code more readable instead of the poorly readable code from by using method **List(of T).Add**:

    genomes += New GenomeBrief With {
        .Name = title,
        .Size = last.Size,
        .Y = h1
    }

	' Poorly readable
    genomes.Add(New GenomeBrief With {
            .Name = title,
            .Size = last.Size,
            .Y = h1
        })

##VisualBasic identifer names

####Directory type
If possible, then all of the directory path variable can be **UPCASE**, such as:

	Dim DIR As String = "/home/xieguigang/Downloads"
	Dim EXPORT As String = "/usr/lib/GCModeller/"

####Module variable
All of the module variable should in format like **_lowerUpper** if the variable is _private_
But if the variable is _Public_ or _Friend_ visible, then it should in format like **UpperUpper**

Here is some example:

	' Private
	Dim _fileName As String
	Dim _inDIR As Directory

	' Public
	Public ReadOnly Property FileName As String
	Public ReadOnly Property InDIR As Directory

####Local varaible
If possible, all of the local varaible within a function or sub program, should be in format **lowerUpper**

####String manipulate
######1. String.Format
For formatted a string output, then recommended used **String.Format** function or string interpolate syntax in VisualBasic language.
And by using the **String.Format** function, then format control string is recommended puts in a constant variable instead of directly used in the format function:

	Const OutMsg As String = "Hello world, {0}, Right?"
	' blablabla.......
	Dim msg As String = String.Format(OutMsg, name)

######2. String contacts
For contacts a large amount of string tokens, the **StringBuilder** is recommended used for this job, not recommend directly using & operator to contacts a large string collection due to the reason of performance issue.
If you just want to contact the string, then a shared method **String.Join** is recommended used:

	Dim tokens As String()
	Dim sb As New StringBuilder

	For Each s As String In tokens
		Call sb.Append(s & " ")
	Next
	Call sb.Remove(sb.Length -1)

Or just use **String.Join**

	Dim tokens As String()
	Dim out As String = String.Join(" ", tokens)

######3. String interpolate
The string interpolate syntax in VisualBasic language is recommended used for **build _SQL_ statement and _CLI_ arguments as this syntax is very easily for understand and code readable**:

	Dim SQL As String = $"SELECT * FROM table WHERE id='{id}' AND ppi>{ppi}"
	Dim CLI As String = $"/start /port {port} /home {PathMapper.UserHOME}"

So, using this syntax feature makes your code very easy for reading and understand the code meaning, right?

####Linq Expression
All of the Linq Expression is recommended execute using [**LinqAPI**]() if the output type of the expression is a known type:

![](https://raw.githubusercontent.com/xieguigang/VisualBasic_AppFramework/master/vb_codestyle/LinqStyle.png)

####Function And Type name

For **_Public_** member function, the function name is recommended in formats **UpperUpper**, but if the function is **_Private, Friend, or Protected_** visible, then your function is recommended start with two underlines, likes **\_\_lowerUpper**. The definition of the _Class, Structure_ names is in the same rule as function name.

Here is some function name examples:

	' Private
	Private Function __worker(Of T As I_GeneBrief)(genome As IGenomicsContextProvider(Of T),
                                               	getTF As Func(Of Strands, T()),
                                               	getRelated As Func(Of T, T(), Integer, T()),
                                               	numTotal As Integer,
                                               	ranges As Integer) As Density()
	' Public
	Public Function DensityCis(Of T As I_GeneBrief)(
                              	genome As IGenomicsContextProvider(Of T),
                              	TF As IEnumerable(Of String),
                              	Optional ranges As Integer = 10000) As Density()

![](https://raw.githubusercontent.com/xieguigang/VisualBasic_AppFramework/master/vb_codestyle/FunctionNames.png)


_Make sure your name is short enough_



>1. Some common used name for common types <table>
<tr><td>System.Type</td><td>Recommend Name</td><td>Example</td></tr>
<tr><td>System.Text.StringBuilder</td><td>sb</td><td>Dim sb As New StringBuilder</td></tr>
<tr><td>System.String</td><td>s, str, name, sId, id, x</td><td>Dim s As String<br />
Dim str As String<br />
Dim name As String<br />
Dim sId As String<br />
Dim id As String<br />
Dim x As String
</td></tr>
<tr><td>System.Integer, System.Long</td><td>i, j, n, x</td><td>Dim i As Integer<br />
Dim j As Integer<br />
Dim n As Integer<br />
Dim x As Integer
</td></tr>
<tr><td>System.Object</td><td>x, o, obj, value</td><td>Dim x As Object<br />
Dim o As Object<br />
Dim obj As Object<br />
Dim value As Object
</td></tr>
</table>


>2. Name for some meaning <table>
<tr><td>Meaning</td><td>Recommend Name</td><td>Example</td></tr>
<tr><td>Commandline arguments</td><td>args, CLI</td><td>Dim args As CommandLine<br />
Dim CLI As String<br />
Dim args As String()
</td></tr>
<tr><td>SQL query</td><td>SQL, sql, query</td><td>Dim SQL As String = "SELECT * FROM table LIMIT 1;"</td></tr>
</table>