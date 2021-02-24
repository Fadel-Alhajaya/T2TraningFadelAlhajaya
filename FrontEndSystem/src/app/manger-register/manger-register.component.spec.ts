import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MangerRegisterComponent } from './manger-register.component';

describe('MangerRegisterComponent', () => {
  let component: MangerRegisterComponent;
  let fixture: ComponentFixture<MangerRegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MangerRegisterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MangerRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
