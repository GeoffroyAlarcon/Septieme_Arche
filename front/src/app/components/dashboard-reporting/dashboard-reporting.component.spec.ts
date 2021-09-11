import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardReportingComponent } from './dashboard-reporting.component';

describe('DashboardReportingComponent', () => {
  let component: DashboardReportingComponent;
  let fixture: ComponentFixture<DashboardReportingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardReportingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardReportingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
