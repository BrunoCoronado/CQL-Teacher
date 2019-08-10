import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PanelSalidaComponent } from './panel-salida.component';

describe('PanelSalidaComponent', () => {
  let component: PanelSalidaComponent;
  let fixture: ComponentFixture<PanelSalidaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PanelSalidaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PanelSalidaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
