import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable()
export class AdminAuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate() {
        if (localStorage.getItem('adminCustomer')) {

            // logged in user so return true
            return true;
        }

        // if not logged in so redirect to login page
        this.router.navigate(['/Login']);
        return false;
    }
}