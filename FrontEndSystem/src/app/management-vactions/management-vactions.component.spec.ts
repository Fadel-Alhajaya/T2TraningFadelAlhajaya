import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagementVactionsComponent } from './management-vactions.component';

describe('ManagementVactionsComponent', () => {
  let component: ManagementVactionsComponent;
  let fixture: ComponentFixture<ManagementVactionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagementVactionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagementVactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
