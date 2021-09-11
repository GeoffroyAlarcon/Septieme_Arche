import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthByMarketingComponent } from './auth-by-marketing.component';

describe('AuthByMarketingComponent', () => {
  let component: AuthByMarketingComponent;
  let fixture: ComponentFixture<AuthByMarketingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthByMarketingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthByMarketingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
