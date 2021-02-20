import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MangeComponent } from './mange.component';

describe('MangeComponent', () => {
  let component: MangeComponent;
  let fixture: ComponentFixture<MangeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MangeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
