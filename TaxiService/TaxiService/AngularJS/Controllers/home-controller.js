app.controller('HomeController', ['$scope', '$location', function ($scope, $location) {

    var self = this;

    init();

    function init() {
        if (!$scope.mainCtrl.username) {
            $location.path('/Login');
        }
    }

}]);