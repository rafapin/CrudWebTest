import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersStartComponent } from './users-start.component';

describe('UsersStartComponent', () => {
  let component: UsersStartComponent;
  let fixture: ComponentFixture<UsersStartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersStartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UsersStartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
