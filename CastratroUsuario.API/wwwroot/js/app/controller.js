var EmpControllers = angular.module("EmpControllers", []);

EmpControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/user').success(function (data) {
            $scope.users = data;
        });
    }
]);

EmpControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {

        $scope.save = function () {
            var obj = {
                id: $scope.id,
                name: $scope.name,
                age: $scope.age,
                address: $scope.address
            };
            //if ($scope.id === 0) {
                $http.post('/api/user/', obj).success(function (data) {
                    $location.path('/list');

                    console.log("aqui");
                }).error(function (data) {
                    $scope.error = "An error has occured while adding user! " + data.ExceptionMessage;

                    console.log("ali");
                });
            //}
            //else {
            //    $http.put('/api/user/', obj).success(function (data) {
            //        $location.path('/list');
            //    }).error(function (data) {
            //        console.log(data);
            //        $scope.error = "An Error has occured while Saving user! " + data.ExceptionMessage;
            //    });
            //}
        };

        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit User";

            $http.get('/api/user/' + $routeParams.id).success(function (data) {
                $scope.name = data.name;
                $scope.age = data.age;
                $scope.address = data.address;
                //$scope.getStates();
            });
        }
        else {
            $scope.title = "Create New User";
        }
    }

]); 