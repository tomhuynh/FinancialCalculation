# CoffeeScript
app = angular.module 'app', ['ngRoute']

app.controller 'DemoCtrl', ['$scope', 'demoService'
($scope,demoService) ->

    $scope.Income1 = 60000
    $scope.Income2 = 30000
    
    $scope.hideRows = false
    $scope.hideRow = ->
        $scope.hideRows = !$scope.hideRows

    $scope.alerts = "loading"
    demoService.getAlerts().then (ret) ->    
        $scope.alerts = ret;
        
    $scope.closeAlert = (index) ->
       $scope.alerts.splice index,1
       
    $scope.myalert = 
      Id = 0
    
    $scope.type = ""
    
    $scope.$watch 'myalert.Id', (val) ->
        if val is 1
            $scope.type = "alert-info"
        else if val is 2
            $scope.type = "alert-warning"
        else if val is 3        
            $scope.type = "alert-danger"

    $scope.calculateOOOutput = (Income1,Income2) ->
        demoService.calculateOOOutput(Income1, Income2).then (ret) ->
             $scope.OOOOuput = ret

    $scope.calculateEPPlusOutput = (Income1,Income2) ->
        demoService.calculateEPPlusOutput(Income1,Income2).then (ret) ->
             $scope.EPOuput = ret

    $scope.downloadExcel = () ->
        demoService.downloadExcel($scope.alerts).then (ret) ->
             $scope.EPOuput = ret
             
    $scope.calculateMemoryOutput = (Income1,Income2) ->
       demoService.calculateMemoryOutput(Income1,Income2).then (ret) ->
             $scope.MemoOuput = ret

]