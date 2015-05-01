angular.module('app').
config ['BASE_WEB_URL','$routeProvider', '$locationProvider',
(BASE_WEB_URL, $routeProvider, $locationProvider) ->
    $locationProvider.html5Mode true
        
    $routeProvider
        .when('/home'
            templateUrl: "#{BASE_WEB_URL}/Scripts/angular/alert/alert.html" 
            controller: 'DemoCtrl'
        )
        .otherwise redirectTo: '/home'
]