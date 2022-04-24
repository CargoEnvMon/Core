import React, {useState} from 'react';
import {Button, Container, Navbar, NavbarBrand} from 'reactstrap';
import {Link} from 'react-router-dom';
import {ShipmentDialog} from "./ShipmentDialog";

import './NavMenu.css';

export function NavMenu() {
  const [open, setOpen] = useState(false);
  
  return (
    <header>
      <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
        <Container>
          <NavbarBrand tag={Link} to="/">CargoEnvMon</NavbarBrand>
          <Button onClick={() => setOpen(true)}>Create shipment</Button>
        </Container>
        <ShipmentDialog open={open} onClose={() => setOpen(false)}/>
      </Navbar>
    </header>
  );
}