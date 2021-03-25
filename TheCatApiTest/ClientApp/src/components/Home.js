import React, { Component } from 'react';
import TablePagination from '@material-ui/core/TablePagination';
import Table from './Table';

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { categories: [], images: [], imagesCount: 0, loading: true, limit: 10, page: 1 };
        this.handleFilter = this.handleFilter.bind(this);
        this.handleChangeRowsPerPage = this.handleChangeRowsPerPage.bind(this);
        this.handleChangePage = this.handleChangePage.bind(this);
    }

    componentDidMount() {
        this.populateCategories();
    }

    async handleFilter(categoryId) {
        await this.setState({ page: 1, categoryId: categoryId });
        this.populateImages();
    }

    async handleChangePage(event, newPage) {
        await this.setState({ page: newPage + 1 });
        this.populateImages();
    };

    async handleChangeRowsPerPage(event) {
        await this.setState({ page: 1, limit: event.target.value });
        this.populateImages();
    };

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <div>
                <Table categories={this.state.categories} data={this.state.images} onFilter={this.handleFilter} />
                <TablePagination
                    component="div"
                    count={this.state.imagesCount}
                    page={this.state.page - 1}
                    onChangePage={this.handleChangePage}
                    rowsPerPage={this.state.limit}
                    onChangeRowsPerPage={this.handleChangeRowsPerPage} />
            </div>;

        return (
            <div>
                {contents}
            </div>
        );
    }

    async populateImages() {
        const response = await fetch('images?categoryId=' + this.state.categoryId + '&page=' + this.state.page + '&limit=' + this.state.limit, { method: 'GET' });
        const data = await response.json();
        this.setState({ images: data.items, imagesCount: data.totalCount });
    }

    async populateCategories() {
        const response = await fetch('categories', { method: 'GET' });
        const data = await response.json();
        this.setState({ categories: data, loading: false });
    }
}
