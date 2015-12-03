Ext.Loader.setConfig({ enabled: true });
Ext.Loader.setPath('Ext', '~/Content/extjs');

Ext.onReady(function () {
    var panel = Ext.create('Ext.panel.Panel', {
        title: 'FurnitureStore',
        height: 700,
        renderTo: 'test',
        layout: 'border',
        defaults: {
            padding: '3'
        },
        items: [{
            xtype: 'panel',
            region: 'west',
            title: 'Navigation',
            width: 150,
            html: '<div></div>',
            tbar: [
              { xtype: 'button', text: 'Button 1' }
            ]
        }, {
            xtype: 'panel',
            region: 'center',
            title: 'Workshit',
            html: '<div id="create"></div>',
            tbar: [
              { xtype: 'button', text: 'Create role' }
            ],
            lbar: [
              button
            ]
        }]
    });

    var button = Ext.create('Ext.button.Button', {
        handler: function () {
            myForm.save();
        }
    });
    Ext.create('Ext.data.Store', {
        storeId: 'sampleStore',
        fields: [
            { name: 'ID', type: 'string' },
            { name: 'NAME', type: 'string' },
            { name: 'AddedDateSerialized', type: 'date' }
        ],
        data: myData
    });

    var roleDom = Ext.getDom('create');

    Ext.create('Ext.grid.Panel', {
        title: 'Roles',
        store: Ext.data.StoreManager.lookup('sampleStore'),
        columns: [
            { text: 'Role ID', dataIndex: 'ID', flex: 1, visible: false },
            { text: 'Role name', dataIndex: 'NAME', flex: 1 },
            { text: 'Added date', dataIndex: 'AddedDateSerialized', xtype: 'datecolumn', format: 'Y-m-d' },
            {
                xtype: 'actioncolumn', width: 50,
                items: [{
                    icon: '../Content/extjs/icons/edit.png',  // Use a URL in the icon config
                    tooltip: 'Edit',
                    triggerEvent: 'cellclick',
                    handler: function (grid, rowIndex, colIndex) {
                        var rec = grid.getStore().getAt(rowIndex);
                        var Id = rec.get('ID');
                        window.open('@Url.Action("Edit", "Role")' + "?Id=" + Id, "_self")
                        //alert("Edit " + rec.get('ID'));
                    }
                },
                    {
                        icon: '../Content/extjs/icons/delete.gif',
                        tooltip: 'Delete',
                        handler: function (grid, rowIndex, colIndex) {
                            var rec = grid.getStore().getAt(rowIndex);
                            var Id = rec.get('ID');
                            window.open('@Url.Action("Delete", "Role")' + "?Id=" + Id, "_self")
                            //alert("Terminate " + rec.get('ID'));
                        }
                    }]
            }
        ],
        renderTo: roleDom,
        viewConfig: {
            stripeRows: true,
            enableTextSelection: true
        }
    });
});

