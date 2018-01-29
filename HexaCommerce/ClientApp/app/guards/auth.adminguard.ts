import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable()
export class AdminAuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate() {

        var currentCustomer = localStorage.getItem('currentCustomer');
        if (currentCustomer !== null) {

            // logged in user so chekc if admin
            return JSON.parse(currentCustomer).isAdmin;
        }

        // if not logged in so redirect to login page
        this.router.navigate(['/Login']);
        return false;
    }
}