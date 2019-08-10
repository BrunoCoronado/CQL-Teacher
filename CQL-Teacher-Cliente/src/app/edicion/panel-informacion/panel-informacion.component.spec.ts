import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PanelInformacionComponent } from './panel-informacion.component';

describe('PanelInformacionComponent', () => {
  let component: PanelInformacionComponent;
  let fixture: ComponentFixture<PanelInformacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PanelInformacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PanelInformacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
