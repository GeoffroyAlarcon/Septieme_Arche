import { Injectable } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { CanActivate, Router } from '@angular/router';

import { AuthGuardGuard } from './auth-guard.guard';
import { UserService } from './UserService';

@Injectable()
export class AuthGuardService implements CanActivate {
constructor(public auth: UserService, public router: Router) {}
canActivate(): boolean {
  if (!this.auth.isAuthenticated()) {
    this.router.navigate(['login']);
    return false;
  }
  return true;
}
}