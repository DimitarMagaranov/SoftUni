function Header(props) {
  let headingMessage = "Hello React World";

  return (
    <header className="header">
      <h1>{props.children}</h1>
      <h2>The Best Framework Ever</h2>
    </header>
  );
}

export default Header;
