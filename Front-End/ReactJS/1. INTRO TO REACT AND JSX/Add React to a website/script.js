const domelement = document.getElementById('root');

// const reactEleemnt = React.createElement('header', {},
//     React.createElement('h1', {}, 'Hello from react element'),
//     React.createElement('h2', {}, 'Hello from react element')
// );

const reactJsxElement =
<header>
    <h1>Hello from react JSX element</h1>
</header>;

ReactDOM.render(reactJsxElement, domelement);