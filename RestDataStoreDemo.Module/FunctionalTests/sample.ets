;#DropDB RestDataStoreDemoEasyTest

#Application RestDataStoreDemo.Win
#Application RestDataStoreDemo.Web
#IfDef RestDataStoreDemo.Win

*Action About...
 
*Action OK

#EndIf

#IfDef RestDataStoreDemo.Web
!Action Navigation(My Details)
#EndIf
