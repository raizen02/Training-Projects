using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Exercise1
    {
    }
}

//Namespace Cti
//    Public Class Employee
//        Private _Name As String
//        Public Property Name() As String
//            Get
//                Return _Name
//            End Get
//            Set(ByVal value As String)
//                _Name = value
//            End Set
//        End Property
//        Public Overridable Sub ClockIn()
//            TapAccessCard()
//        End Sub
//        Private Sub TapAccessCard()
//            'Log Time In
//        End Sub
//        Public Sub GoHome()

//        End Sub
//    End Class
//    Public Class Engineer
//        Inherits Employee
//        Implements IEmployees
//        Sub DoWork() Implements IEmployees.DoWork
//            'Setup Server
//        End Sub
//    End Class
//    Public Class Programmer
//        Inherits Employee
//        Implements IEmployees
//        Sub DoWork() Implements IEmployees.DoWork
//            'Fix Application Bug
//        End Sub

//        'Requirement 3: Analyst/Programmer Clock In/Out is based on the Web Clock In.
//        'The other approaches that all of you have done can be also the other way of doing it. But in programming,
//        'those might lead to other problems.

//        Public Overrides Sub ClockIn()
//            LoginToWebClock(timelogs)
//        End Sub
//        Public Sub LoginToWebClock()
//            'Perform Login
//        End Sub
//        Public Overloads Sub GoHome(ByVal s As String)

//        End Sub
//    End Class
//    Public Class Manager
//        Inherits Employee
//        Implements IEmployees
       
//        'Requirement 1: Only the IT Manager should be able to execute the ApproveLeave Method.
//        'The Method was placed in the Manager Derived class to make sure that only the Manager can do it
//        Sub ApproveLeave()

//        End Sub
//        Sub DoWork() Implements IEmployees.DoWork
//            'Create Weekly Report
//        End Sub
//    End Class

//    'Requirement 2 : All Employees should have the DoWork Method that performs unique routines based on their roles
//    'Create an interface that will force all employees to have DoWork method.
//    Public Interface IEmployees
//        Sub DoWork()
//    End Interface
//End Namespace





