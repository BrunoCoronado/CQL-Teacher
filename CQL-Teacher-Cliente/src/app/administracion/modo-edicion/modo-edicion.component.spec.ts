import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModoEdicionComponent } from './modo-edicion.component';

describe('ModoEdicionComponent', () => {
  let component: ModoEdicionComponent;
  let fixture: ComponentFixture<ModoEdicionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModoEdicionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModoEdicionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
