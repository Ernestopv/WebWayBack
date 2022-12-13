import React from "react";
import { Navbar, NavbarBrand, Button } from "reactstrap";
import "./NavMenu.css";

export function NavMenu() {
  return (
    <div>
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          container
          light
        >
          <NavbarBrand>WayBack Machine ©</NavbarBrand>
        </Navbar>
      </header>
    </div>
  );
}
