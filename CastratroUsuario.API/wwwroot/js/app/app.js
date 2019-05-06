var EmpApp = angular.module('EmpApp', ['ngRoute', 'EmpControllers']);

EmpApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
    when('/list',
    {
        templateUrl: 'User/list.html',
        controller: 'ListController'
    }).
    when('/create',
    {
        templateUrl: 'User/edit.html',
        controller: 'EditController'
    }).
    when('/edit/:id',
    {
        templateUrl: 'User/edit.html',
        controller: 'EditController'
    }).
    otherwise(
    {
        redirectTo: '/list'
    });
}]); 