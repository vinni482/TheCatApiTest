import React, { Component } from 'react';

export default class Table extends Component {

    render() {
        const { data } = this.props;
        const { categories } = this.props;

        return (
            <table className='table table-hover' aria-labelledby="tabelLabel">
                <thead>
                    <tr className="filters">
                        <th>
                            <select className="form-control" onChange={e => { this.props.onFilter(e.target.value); }}>
                                <option value="0">Select Category</option>
                                {categories.map(category =>
                                    <option value={category.id} key={category.id}>{category.name}</option>
                                )}
                            </select>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(image =>
                        <tr key={image.id}>
                            <td>
                                <a href={image.url} target="_blank" rel="noopener noreferrer"><img src={image.url} height="200" alt="There must be a cat" /></a>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}
