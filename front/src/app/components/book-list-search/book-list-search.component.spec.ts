import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookListSearchComponent } from './book-list-search.component';

describe('BookListSearchComponent', () => {
  let component: BookListSearchComponent;
  let fixture: ComponentFixture<BookListSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookListSearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookListSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
