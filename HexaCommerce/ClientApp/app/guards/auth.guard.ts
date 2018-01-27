import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate()
    {
        if (localStorage.getItem('registeredCustomer')) {

            // logged in user so return true
            return true;
        }

        // if not logged in so redirect to login page
        this.router.navigate(['/Login']);
        return false;
    }
}