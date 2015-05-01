# CoffeeScript
angular.module('app').
directive 'myalert', [ ->
        restrict: 'EA'
        #templateUrl: 'Scripts/angular/demo/myalert.html'
        template:
            "
                <div class='alert alert-{{type}}'>

                    <button type='button' ng-click='close()'>Hide Me</button>

                    <lable> Reason </lable>
                    <div ng-transclude></div>
                    <input type='text' ng-model='reason' name='reason' />
                </div>        
            "
        replace: true
        transclude: true
        scope:
            reason: "="
            type:"@"
            close: "&"

]
