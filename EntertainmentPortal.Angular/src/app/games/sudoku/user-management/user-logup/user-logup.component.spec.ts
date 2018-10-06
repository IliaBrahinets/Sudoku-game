import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserLogUpComponent } from './user-logup.component';

describe('UserSignUpComponent', () => {
  let component: UserLogUpComponent;
  let fixture: ComponentFixture<UserLogUpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserLogUpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserLogUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
