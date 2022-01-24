

    var app = angular.module('category', []);
        app.controller('myCategory', function ($scope, $http) {

        Clear();
            function Clear() {
        $scope.categoryList = [];
                $scope.dllCategory = null;
                $scope.dllSubCategory = null;



                GetCategory();
            }


            function GetCategory() {
        $http({
            url: "/Category/GetAllCategory",
            method: "GET",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (data) {
            $scope.categoryList = data;
            console.log(data);

        });
            }

        });

  