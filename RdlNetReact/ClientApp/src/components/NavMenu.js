import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
    displayName = NavMenu.name

    openInNewTab = (url) => {
        var win = window.open(url, '_blank');
        if (win != null)
            win.focus();
    }

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>Reidell.Net - Resume API Viewer</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Home
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/resview'}>
              <NavItem>
                <Glyphicon glyph='thumbs-up' /> Resume Viewer
              </NavItem>
            </LinkContainer>
            <LinkContainer  to="#" onClick={e => this.openInNewTab('/pdf')}>
              <NavItem>
                <Glyphicon glyph='glyphicon glyphicon-download-alt' /> Printable Resume
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
