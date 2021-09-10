import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

import { Observable } from 'rxjs';
import { UserService } from './UserService';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
  constructor(private userService: UserService, private router: Router) { }
  canActivate(): boolean {
    if (!this.userService.isAuthenticated()) {
      this.router.navigate(["auth"]);
      return false;
    }
    return true;
  }
}
