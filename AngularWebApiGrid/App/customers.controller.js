(function () {
    'use strict';

    angular
        .module('app')
        .controller('CustomersController', CustomersController);

    CustomersController.$inject = ['$location']; 

    function CustomersController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'CustomersController';

        activate();

        function activate() { }
    }
})();