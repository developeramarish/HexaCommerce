import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
})
export class NavMenuComponent implements OnInit {
    private data: any;
    ifCustomerLoggedIn: boolean;
    ifAdminCustomer: boolean;

    constructor() { };

    ngOnInit() {
        const userJson = localStorage.getItem('currentCustomer');
        this.ifCustomerLoggedIn = userJson !== null;
        this.ifAdminCustomer = userJson !== null ? JSON.parse(userJson).isAdmin : null;
    }
}

