import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
})
export class NavMenuComponent implements OnInit {
    private data: any;
    IsCustomerLoggedIn: boolean;
    IsAdminCustomer: boolean;

    constructor() { };

    ngOnInit() {
        const userJson = localStorage.getItem('currentCustomer');
        this.IsCustomerLoggedIn = userJson !== null;
        this.IsAdminCustomer = userJson !== null ? JSON.parse(userJson).isAdmin : null;
    }
}

