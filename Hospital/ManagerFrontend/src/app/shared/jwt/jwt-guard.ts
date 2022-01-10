import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { ToastrService } from "ngx-toastr";


@Injectable()
export class ManagerGuard implements CanActivate {

    constructor(private router: Router, private toast: ToastrService){}

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if(!localStorage.getItem('jwt') || !localStorage.getItem('currentUser') || 
        JSON.parse(localStorage.getItem('currentUser') || '{}')?.loginType !== 1) {
            this.router.navigate(['/']);
            localStorage.removeItem('jwt')
            localStorage.removeItem('currentUser')
            this.toast.error('You need to login!')
            return false;
        }
        return true;
    }
}