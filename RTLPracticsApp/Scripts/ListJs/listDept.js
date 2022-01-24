
var app = angular.module('myDept', []);

app.controller('DeptController', function ($http,$scope) {

    Clear();
    function Clear() {
        $scope.add_department = {};
        $scope.ddlDepartment = null;
        $scope.departmentListArray = [];
        $scope.add_Student = {};
        $scope.studentListArray = [];
        GetDepartment();
        GetAllStudent();

        $scope.MailSendObject = {};
    }

    $scope.dataSavedAll = function () {
        var prams = JSON.stringify({ dept: $scope.add_department });
    
        $http.post("/TestCat/SaveDept", prams).then(function (data) {

          //  $scope.ddlDepartment = { "Id": data };

            $http({
                url: "/TestCat/GetAllDepartment",
                method: "GET",
            }).then(function (response) {
                $scope.departmentListArray = response.data;
                angular.forEach($scope.departmentListArray, function (aData) {
                    if (data == aData.Id) {
                        $scope.ddlDepartment = aData.Id;
                    }
                });
            });
            //console.log($scope.ddlDepartment);
           // $scope.ddlDepartment = { "Id": data };
           
         
            $('#deptmodal').modal('hide');
        });

        //DeptSave();
       
    }

    //function DeptSave() {
    //    $.ajax({
    //        url: "/TestCat/SaveDept",
    //        method: "POST",
    //        data: JSON.stringify({ dept: $scope.add_department }),
    //        dataType: "Json",
    //        success: function (response) {
    //            console.log(response);
    //        }
    //    });
    //}

    $scope.StudentSave = function () {
        var prams = JSON.stringify({ student: $scope.add_Student });
        $http({
            url: "/TestCat/StudentSave",
            method: "POST",
            data: prams,
            headers: {'Content-Type':'application/json'}
        }).then(function (response) {
            Clear();
            console.log(response);
        });
    }

    $scope.DeptSaveBtn = function () {
        $('#deptmodal').modal('show');
    }
    
    $scope.GetDepartmentChange = function () {

        angular.forEach($scope.studentListArray, function (data) {
            $scope.add_Student.Name = $scope.ddlDepartment.Name;
            $scope.add_Student.Email = $scope.ddlDepartment.Location;
        });
       
    }

    function GetDepartment() {
        $http({
            url: "/TestCat/GetAllDepartment",
            method:"GET",
        }).then(function (response) {
            $scope.departmentListArray =response.data;
           
        });
    }
    function GetAllStudent() {
        $http({
            url: "/TestCat/GetAllStudent",
            method: "GET",
        }).then(function (response) {
            $scope.studentListArray = response.data;
           // console.log($scope.studentListArray);
           
        });
    }

    $scope.SendMail = function () {
        

        var prams = JSON.stringify({ emailSend: $scope.MailSendObject });
        $http({
            url: "/Category/EmailSend",
            method: "POST",
            data: prams,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            
            console.log(response.data);
        });
    }

    //$scope.dowanload = function (e) {
    //    if (confirm("Dowanload")) {
    //        $("#FileDowanLoad").click(function (e) {

    //        })
    //    } else {
    //        $("#FileDowanLoad").click(function () {
    //            $(this).unbind();
    //        });
    //    }
      
        
    //}

    //$("#FileDowanLoad").click(function (e) {
    //    e.stopPropagation();
    //    if (confirm("Dowanload")) {
    //        $("#FileDowanLoad").click(function () {

    //        });
    //    } else {
           
    //    }
        
    //});

   
});