(function () {
    'use strict';

    angular
        .module('app')
        .controller('CustomersController', CustomersController);

    CustomersController.$inject = ['Restangular']; 

    function CustomersController(Restangular) {
        /* jshint validthis:true */
        var vm = this;
        vm.customers = [];

        activate();

        function activate() {
            Restangular.all('customers').getList().then(function(customers) {
                vm.customers = customers;
            });
        }
    }
})();